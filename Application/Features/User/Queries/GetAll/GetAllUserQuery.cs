using MediatR;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.GetAll
{
    public class GetAllUserQuery : IRequest<Response<IReadOnlyList<GetAllUserQueryVm>>>
    {
        public bool IsActive { get; set; }
    }
}
