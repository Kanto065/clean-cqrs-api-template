using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.User.Queries.GetAll;
using MediatR;
using Shared.Wrappers;

namespace Application.Features.User.Queries.Get
{
    public class GetUserQuery : IRequest<Response<GetUserQueryVm>>
    {
        public int Id { get; set; }
    }
}
