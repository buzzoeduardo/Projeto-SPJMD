using ControleSPJMD.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleSPJMD.Controle
{
    public class Controle_Login
    {
        Cmd_Login cmd = new Cmd_Login();
        public string? NomePM { get; private set; }
        public string? IdPM { get; private set; }

        public async Task Login_(string login, string senha)
        {
            await cmd.Login(login, senha);
            IdPM = cmd.IdPM;
            NomePM = cmd.NomePM;
        }
    }
}
