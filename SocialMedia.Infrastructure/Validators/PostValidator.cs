using FluentValidation;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator() {

            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 500);

            RuleFor(post => post.Date)
                .NotNull()
                .LessThan(DateTime.Now);
        
        }
    }
}
