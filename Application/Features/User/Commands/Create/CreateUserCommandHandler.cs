﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Wrappers;

namespace Application.Features.User.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        #region Ctor
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private List<String> _validationError;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateUserCommandHandler> logger)
        {
            _UnitOfWork = unitOfWork;
            _logger = logger;
            _validationError = [];
        }
        #endregion

        public async Task<Response<int>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = new Domain.Entities.User
                {
                    Name = command.Name,
                    Email = command.Email,
                    Phone = command.Phone
                };

                await _UnitOfWork.User.AddAsync(newUser);
                await _UnitOfWork.SaveChangesAsync();

                return Response<int>.Success(newUser.Id, "User Created Successfully");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in CreateUserCommandHandler");
                _validationError.Add(e.Message);
                return Response<int>.Fail("User Creation Failed", _validationError);
            }
        }
    }
}
