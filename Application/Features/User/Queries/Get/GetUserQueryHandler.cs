using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Application.Features.User.Commands.Update;
using Application.Interfaces;
using Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Wrappers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.User.Queries.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Response<GetUserQueryViewModel>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ILogger<GetUserQueryHandler> _logger;
        private List<String> _validationError;
        private readonly IUserService _userServiceHandler;

        public GetUserQueryHandler(IUnitOfWork unitOfWork,
            ILogger<GetUserQueryHandler> logger,
            IUserService userServiceHandler)
        {
            _UnitOfWork = unitOfWork;
            _logger = logger;
            _validationError = new List<string>();
            _userServiceHandler = userServiceHandler;
        }

        public async Task<Response<GetUserQueryViewModel>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //var user = await _UnitOfWork.User.GetByIdAsync(request.Id);
                var user = await _userServiceHandler.GetById(request.Id);
                if (user is null)
                    return Response<GetUserQueryViewModel>.Fail("User not found");

                var userModel = new GetUserQueryViewModel();
                userModel.Id = user.Id;
                userModel.Name = user.Name;
                userModel.Email = user.Email;
                userModel.Phone = user.Phone;

                return Response<GetUserQueryViewModel>.Success(userModel, "Returned user");
                

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in GetUserQueryHandler");
                _validationError.Add(e.Message);
                return Response<GetUserQueryViewModel>.Fail("User not found", _validationError);
            }
        }
    }
}
