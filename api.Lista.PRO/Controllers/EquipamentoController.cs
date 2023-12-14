using api.Lista.PRO.Interfaces;
using api.Lista.PRO.Models;
using api.Lista.PRO.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Lista.PRO.Controllers
{
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamento _equipamento;
        private readonly IValidateEntityId _validateEntityId;

        public EquipamentoController(IEquipamento equipamento, IValidateEntityId validateEntityId)
        {
            _equipamento = equipamento;
            _validateEntityId = validateEntityId;
        }
        [HttpGet]
        public async Task<IActionResult> Equipamentos()
        {
            var equipamentos = _equipamento.PegarTodos();
            return Ok(equipamentos);
        }

        [HttpGet]
        public async Task<IActionResult> Equipamento(int id)
        {
            var equipamentoViewModel = _equipamento.PegarUm(id);
            if (equipamentoViewModel == null)
            {
                return NotFound(new { message = "Equipamento inexistente" });
            }
            return Ok(equipamentoViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Buscar(string seachString)
        {
            try
            {
                var equipamentoViewModel = _equipamento.PorStringValue(seachString);
                if (equipamentoViewModel.Result.Count() == 0)
                {
                    return NotFound(new { message = "Nenhum equipamento com esse nome ou numero de serie encontrado" });
                }
                return Ok(equipamentoViewModel);
            }
            catch
            {
                return BadRequest("Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Criar( EquipamentoViewModel equipamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_validateEntityId.ValidarCondominio(equipamentoViewModel.CondominioId))
                {
                    var newEquip = _equipamento.Criar(equipamentoViewModel.ToEquipamento());
                    return Ok(newEquip ? "Equipamento criado. :)" : "Tente novamente!");
                }
                return NotFound(new { message = "Condominio não existe!" }); 
            };
            return BadRequest("Campos obrigatórios precisam ser preenchidos!");
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(int id)
        {
            var equipamento = _equipamento.PegarUm(id);
            if (equipamento != null)
            {
                _equipamento.Deletar(equipamento);
                return Ok(new { message = "equipamento deletado com sucesso!" });
            }
            return NotFound(new { message = "equipamento não existe!" });
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] EquipamentoViewModel equipamento)
        {
            if (ModelState.IsValid)
            {
                var equipamentoEditado = _equipamento.Editar(equipamento.ToEquipamento());
                if (equipamentoEditado)
                {
                    return Ok(new { message = "equipamento editado!" });
                }
            }
            return BadRequest();

        }
    }
}
