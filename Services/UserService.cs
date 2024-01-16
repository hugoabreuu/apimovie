using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApi.DTOs.UserDTOs;
using WebApi.Models;

namespace WebApi.Services;
public class UserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signManager;
    private readonly TokenService _tokenService;
    private readonly IMapper _mapper;
    public UserService(UserManager<User> userManager, IMapper mapper, SignInManager<User> signManager, TokenService tokenService)
    {
        this._userManager = userManager;
        this._mapper = mapper;
        this._signManager = signManager;
        this._tokenService = tokenService;
    }
    /// <summary>
    /// Cria um usuário da api 
    /// </summary>
    /// <param name="userDTO">DTO que contém os dados necessários para criar um usuário</param>
    /// <returns>Retorna uma Tarefa de <see cref="IdentityResult"/> </returns>
    public async Task<IdentityResult> RegisteUserAsync(CreateUserDTO userDTO)
    {
        User user = _mapper.Map<User>(userDTO);
        return await _userManager.CreateAsync(user, userDTO.Password);
    }
    /// <summary>
    /// Autentica usuário na api
    /// </summary>
    /// <param name="loginDTO">DTO que contém os dados necessários para autenticar usuário</param>
    /// <returns>Retorna um token para reivindicar autenticação</returns>
    /// <exception cref="ApplicationException">Exceção lançada se user for inválido</exception>
    public async Task<string> LoginAsync(UserLoginDTO loginDTO)
    {
        var response = await _signManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, false, false);

        if (!response.Succeeded)        
            throw new ApplicationException("Usuário Inválido!");
        
        var user = _signManager.UserManager.Users.FirstOrDefault(x => x.NormalizedUserName == loginDTO.Username.ToUpper())!;
        var token = _tokenService.GenerateUserToken(user);

        return token;
    }
}
