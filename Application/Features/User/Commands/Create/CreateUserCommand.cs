using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shared.Wrappers;

namespace Application.Features.User.Commands.Create
{
    public class CreateUserCommand : IRequest<Response<int>>
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is invalid")]   
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
