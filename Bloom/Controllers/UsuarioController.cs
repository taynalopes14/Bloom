﻿using Bloom.Application.AppServicesInterfaces;
using Bloom.Application.Models;
using Bloom.BLL.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloom.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        //Perfil
        /// <summary>
        /// Retorna as informações do usuário
        /// </summary>
        /// <returns>Token de autenticação</returns>
        /// <response code="200">Token</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpGet]
        [Route("GetInformacoesUser")]
        public IActionResult GetInformacoesUser(string userEmail)
        {
            var resposta = _usuarioAppService.GetInformacoesUser(userEmail);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }

        /// <summary>
        /// Atualiza as informações do usuário
        /// </summary>
        /// <returns>Token de autenticação</returns>
        /// <response code="200">Token</response>
        /// <response code="400">Corpo da requisição inválido</response>  
        [HttpPost]
        [Route("AtualizarUsuario")]
        public IActionResult AtualizarUsuario([FromForm] UpdateUserModel model)
        {
            var resposta = _usuarioAppService.AtualizarUsuario(model);
            if (resposta.Sucesso)
            {
                return Ok(resposta);
            }

            return BadRequest(resposta);
        }
    }
}
