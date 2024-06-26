﻿using DNTCaptcha.Core;
using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Infrastructure.PasswordHasher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ItemBoxStore.API.Controllers.Users
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    [ApiController]
    [Route(template: "[controller]")]
    public partial class UserController(
        IUserService userService,
        ILogger<UserController> logger,
        IPasswordHasher passwordHasher,
        IDNTCaptchaApiProvider apiProvider,
        IDNTCaptchaValidatorService validatorService,
        IOptions<DNTCaptchaOptions> options
        ) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        private readonly ILogger<UserController> _logger = logger;

        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        private readonly IDNTCaptchaApiProvider _apiProvider = apiProvider;

        private readonly IDNTCaptchaValidatorService _validatorService = validatorService;

        private readonly DNTCaptchaOptions _captchaOptions = options == null ? throw new ArgumentNullException(nameof(options)) : options.Value;





    }
}
