using Core.Entities.Identity;

namespace Core.Interface
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}