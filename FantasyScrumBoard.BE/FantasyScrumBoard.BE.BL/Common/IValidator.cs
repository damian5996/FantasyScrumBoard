namespace FantasyScrumBoard.BE.BL.Common
{
    public interface IValidator<in TParam>
    {
        void Validate(TParam param);
    }
}
