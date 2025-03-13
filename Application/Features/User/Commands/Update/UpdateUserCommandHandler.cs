using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Application.Features.User.Commands.Create;
using Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Wrappers;

namespace Application.Features.User.Commands.Update
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<int>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        private List<String> _validationError;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateUserCommandHandler> logger)
        {
            _UnitOfWork = unitOfWork;
            _logger = logger;
            _validationError = [];
        }

        public async Task<Response<int>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _UnitOfWork.User.GetByIdAsync(command.Id);
                if (user is null)
                {
                    _validationError.Add("User not found");
                    return Response<int>.Fail("User not found", _validationError);
                }
                else
                {
                    user.Name = command.Name;
                    user.Email = command.Email;
                    user.Phone = command.Phone;
                    await _UnitOfWork.User.UpdateAsync(user);
                    await _UnitOfWork.SaveChangesAsync();
                    return Response<int>.Success(user.Id, "User Updated Successfully");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in UpdateUserCommandHandler");
                _validationError.Add(e.Message);
                return Response<int>.Fail("User Update Failed", _validationError);
            }
        }
    }
}
