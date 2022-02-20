
using GesBudgetaire.Models;
using GesBudgetaire.Models.Repository.GesBudgetaire;
using GesBudgetaire.utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace GesBudgetaire.Controllers.GesBudgetaire
{
    [Route("api/utilisateur")]
    public class UtilisateurController : ControllerBase
    {
        private IUtilisateurRepository utilisateurRepository;

        public UtilisateurController(IUtilisateurRepository repository)
        {
            this.utilisateurRepository = repository;
        }

        [HttpGet]
        public IEnumerable<Utilisateur> List() => utilisateurRepository.ListUtilisateur;

        [HttpGet("{idutilisateur}")]
        public async Task<IActionResult> GetById(int idutilisateur)
        {
            if (utilisateurRepository.UtilisateurExists(idutilisateur))
            {
                return Ok(utilisateurRepository[idutilisateur]);
            }
            ModelState.AddModelError("Utilisateur", "l' utilisateur n'existe pas ");
            return BadRequest(ModelState);
        }

        [HttpPost]
        public Utilisateur Add([FromBody] Utilisateur utilisateur)
        {
            Utilisateur user = null;

            utilisateur.Password = Hash.GetHash(utilisateur.Password);


            user = utilisateurRepository.Add(utilisateur);

            if (user.Equals(null))
            {
                this.HttpContext.Response.StatusCode = 400;
                return (user);
            }
            this.HttpContext.Response.StatusCode = 201;
            return (user);
        }

        [HttpDelete("{idutilisateur}")]
        public async Task<IActionResult> Delete(int idutilisateur)
        {
            if (utilisateurRepository.UtilisateurExists(idutilisateur))
            {
                utilisateurRepository.Delete(idutilisateur);
                ModelState.AddModelError("Utilisateur", "utilisateur supprimé avec succés");
                return Ok(ModelState);

            }
            ModelState.AddModelError("Utilisateur", "Impossible de supprimé un utilisateur inexistant ");
            return BadRequest(ModelState);
        }

        [HttpPatch("{idutilisateur}")]
        public async Task<IActionResult> UpdateProperties(int idutilisateur, [FromBody] JsonPatchDocument<Utilisateur> patch)
        {

            if (utilisateurRepository.UtilisateurExists(idutilisateur))
            {
                Utilisateur user = utilisateurRepository[idutilisateur];
                patch.ApplyTo(user);
                return Ok(utilisateurRepository.UpdateAsync(user));
            }
            ModelState.AddModelError("Utilisateur", "Impossible de mettre à jour un utilisateur introuvable");
            return BadRequest(ModelState);


        }
    }
}
