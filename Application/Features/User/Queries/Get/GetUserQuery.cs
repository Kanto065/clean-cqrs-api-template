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
    public class GetUserQuery : IRequest<Response<GetUserQueryViewModel>>
    {
        public int Id { get; set; }
    }
    public class GetUserQueryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
