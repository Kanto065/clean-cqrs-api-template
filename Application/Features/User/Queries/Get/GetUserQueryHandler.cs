using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Application.Features.User.Commands.Update;
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

        public GetUserQueryHandler(IUnitOfWork unitOfWork, ILogger<GetUserQueryHandler> logger)
        {
            _UnitOfWork = unitOfWork;
            _logger = logger;
            _validationError = [];
        }

        public async Task<Response<GetUserQueryViewModel>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _UnitOfWork.User.GetByIdAsync(request.Id);
                if (user is null)
                {
                    _validationError.Add("User not found");
                    return Response<GetUserQueryViewModel>.Fail("User not found", _validationError);
                }
                else
                {
                    var userModel = new GetUserQueryViewModel();
                    userModel.Id = user.Id;
                    userModel.Name = user.Name;
                    userModel.Email = user.Email;
                    userModel.Phone = user.Phone;

                    return Response<GetUserQueryViewModel>.Success(userModel, "Returend user");
                }

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
