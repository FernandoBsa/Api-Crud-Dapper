﻿using Domain.Enum;

namespace Domain.Request;

public class UsuarioEditarRequest
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public string Senha { get; set; }
    public Situation Situation { get; set; }
    public UserType UserType { get; set; }
}