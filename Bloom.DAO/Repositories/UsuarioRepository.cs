﻿using Bloom.BLL.Entities;
using Bloom.BLL.RepositoriesInterfaces;
using Bloom.DAO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bloom.DAO.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly DbSet<Usuario> _usuarios;

        public UsuarioRepository(BloomContext context, IConfiguration configuration)
            : base(context, configuration)
        {
            _usuarios = _context.Usuarios;
        }

        public Usuario GetByEmail(string email)
        {
            return _usuarios.Where(x => x.Email == email).FirstOrDefault();
        }
    
    }
}
