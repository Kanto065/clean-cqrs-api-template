using Application.Features.User.Queries.Get;
using Application.Interfaces;
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
        private readonly ILogger<GetAllUserQueryHandler> _logger;
        private List<String> _validationError;
        private readonly IUserService _userServiceHandler;

        public GetAllUserQueryHandler(
            ILogger<GetAllUserQueryHandler> logger,
            IUserService userServiceHandler)
        {
            _logger = logger;
            _validationError = [];
            _userServiceHandler = userServiceHandler;
        }

        public async Task<Response<IReadOnlyList<GetAllUserQueryVm>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allUser = await _userServiceHandler.GetAll();

                if (!allUser.Any())
                    return Response<IReadOnlyList<GetAllUserQueryVm>>.Fail("User not found");

                var Users = allUser.Select(x => new GetAllUserQueryVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone
                }).OrderByDescending(x => x.Id)
                .ToList();

                return Response<IReadOnlyList<GetAllUserQueryVm>>.Success(Users, "Returned all user");
                
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
