using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.User.Commands.Update;
using Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Wrappers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.User.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<bool>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ILogger<DeleteUserCommandHandler> _logger;
        private List<String> _validationError;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteUserCommandHandler> logger)
        {
            _UnitOfWork = unitOfWork;
            _logger = logger;
            _validationError = [];
        }

        public async Task<Response<bool>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _UnitOfWork.User.GetByIdAsync(command.Id);
                if (user is null)
                {
                    _validationError.Add("User not found");
                    return Response<bool>.Fail("User not found", _validationError);
                }
                else
                {
                    await _UnitOfWork.User.DeleteAsync(user);
                    await _UnitOfWork.SaveChangesAsync();
                    return Response<bool>.Success(true, "User Updated Successfully");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in DeleteUserCommandHandler");
                _validationError.Add(e.Message);
                return Response<bool>.Fail("User Delete Failed", _validationError);
            }
        }
    }
}
