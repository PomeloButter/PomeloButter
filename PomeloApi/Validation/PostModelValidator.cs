using FluentValidation;
using PomeloButter.Model.ViewModel;


namespace PomeloApi.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public class PostModelValidator : AbstractValidator<PostModel>
    {
        /// <summary>
        /// 
        /// </summary>
        public PostModelValidator()
        {
            RuleFor(x => x.Author).NotNull().WithName("作者").WithMessage("{PropertyName}是必须的").MaximumLength(50).WithMessage("{propertyName}的最大长度是{MaxLength}");
        }
    }
}