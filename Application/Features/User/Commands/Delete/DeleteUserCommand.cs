using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shared.Wrappers;

namespace Application.Features.User.Commands.Delete
{
    public class DeleteUserCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
    }
}
