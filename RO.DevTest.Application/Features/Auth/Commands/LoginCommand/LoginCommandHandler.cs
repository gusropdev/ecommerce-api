using MediatR;
using Microsoft.Extensions.Configuration;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;
public class LoginCommandHandler (IIdentityAbstractor identityAbstractor, ITokenService tokenService)
    : IRequestHandler<LoginCommand, LoginResponse>
{

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await identityAbstractor.FindUserByEmailAsync(request.Email);
        if (user == null)
            throw new BadRequestException("Credenciais inválidas");

        var isPasswordValid = await identityAbstractor.CheckPasswordAsync(user, request.Password);
        if (!isPasswordValid)
            throw new BadRequestException("Credenciais inválidas");

        var roles = await identityAbstractor.GetRolesAsync(user);

        var accessToken = await tokenService.GenerateAccessToken(user, roles);

        return new LoginResponse
        {
            AccessToken = accessToken,
            Roles = roles,
            IssuedAt = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.AddDays(1)
        };
    }
}