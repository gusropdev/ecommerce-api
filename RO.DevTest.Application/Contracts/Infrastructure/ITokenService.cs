using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Contracts.Infrastructure;

public interface ITokenService
{
    Task<string> GenerateAccessToken(User user, IList<string> roles);
}