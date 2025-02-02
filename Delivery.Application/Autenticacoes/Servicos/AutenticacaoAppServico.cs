using Delivery.Application.Autenticacoes.Servicos.Interfaces;
using Delivery.DataTransfer.Autenticacoes.Requests;
using Delivery.DataTransfer.Autenticacoes.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Autenticacoes.Servicos
{
    public class AutenticacaoAppServico : IAutenticacaoAppServico
    {
        public AutenticacaoResponse Login(LoginRequest request)
        {
            return new AutenticacaoResponse(Guid.NewGuid(), "nome", "sobrenome", "email", "token");
        }

        public AutenticacaoResponse Registro(RegistroRequest request)
        {
            return new AutenticacaoResponse(Guid.NewGuid(), "nome", "sobrenome", "email", "token");
        }


        public bool Valido(int[][] grid, int numRobots)
        {
            int[] position1 = { };
            int count = 0;

            for(int i = 0; i < grid[0].Length; i++)
            {
                if (grid[0][i] == 1)
                {
                    position1.Append(i);
                }
            }

            if(position1.Length != numRobots)
                return false;

            for(int i = 0; i < grid[1].Length; i++)
            {
                if (grid[1][i] == 1)
                {
                    if (position1[count] != i + 1 && position1[count] != i - 1 && position1[count] != i)
                        return false;
                    count += 1;
                }
            }

            return true;
        }
    }
}
