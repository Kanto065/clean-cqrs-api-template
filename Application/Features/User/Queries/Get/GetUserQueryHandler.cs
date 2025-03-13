using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shared.Wrappers;

namespace Application.Features.User.Queries.Get
{
    internal class GetUserQueryHandler : IRequestHandler<GetUserQuery, Response<GetUserQueryVm>>
    {
        public Task<Response<GetUserQueryVm>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
