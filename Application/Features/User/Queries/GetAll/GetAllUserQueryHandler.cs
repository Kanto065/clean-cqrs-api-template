using Application.Features.User.Queries.Get;
using Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, Response<IReadOnlyList<GetAllUserQueryVm>>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ILogger<GetAllUserQueryHandler> _logger;
        private List<String> _validationError;

        public GetAllUserQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllUserQueryHandler> logger)
        {
            _UnitOfWork = unitOfWork;
            _logger = logger;
            _validationError = [];
        }

        public async Task<Response<IReadOnlyList<GetAllUserQueryVm>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allUser = _UnitOfWork.User.AsNoTracking().ToList();
                if (allUser is null)
                {
                    _validationError.Add("No user");
                    return Response<IReadOnlyList<GetAllUserQueryVm>>.Fail("User not found", _validationError);
                }
                else 
                {
                    var Users = new List<GetAllUserQueryVm>();
                    foreach (var user in allUser) 
                    {
                        var userModel = new GetAllUserQueryVm();
                        userModel.Id = user.Id;
                        userModel.Name = user.Name;
                        userModel.Email = user.Email;
                        userModel.Phone = user.Phone;
                        Users.Add(userModel);
                    }
                    return Response<IReadOnlyList<GetAllUserQueryVm>>.Success(Users.OrderByDescending(x => x.Id).ToList(), "Returned all user");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in GetUserQueryHandler");
                _validationError.Add(e.Message);
                return Response<IReadOnlyList<GetAllUserQueryVm>>.Fail("User not found", _validationError);
            }
        }
    }
}
