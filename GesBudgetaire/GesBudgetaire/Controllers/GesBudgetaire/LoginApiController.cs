using GesBudgetaire.Models;
using GesBudgetaire.Models.Repository.GesBudgetaire;
using GesBudgetaire.utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesBudgetaire.Controllers.GesBudgetaire
{
    [Route("api/login")]
    public class LoginApiController : ControllerBase
    {
        private IUtilisateurRepository utilisateurRepository;

        public LoginApiController(IUtilisateurRepository utilisateurRepository)
        {
            this.utilisateurRepository = utilisateurRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Authentification([FromBody] Utilisateur utilisateur)
        {
            Utilisateur current = new Utilisateur();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           /* if (!utilisateurRepository.findByEmail(utilisateur.Email) )
            {
                ModelState.AddModelError("Matricule", "Ce matricule ne possède pas de compte");
                return BadRequest(ModelState);
            }*/

           // utilisateur.Password = Hash.GetHash(utilisateur.Password);
            current = utilisateurRepository.findByEmail(utilisateur.Email);
            if (current.Statut == "I")
            {

                ModelState.AddModelError("Utilisateur", "Ce compte utilisateur doit être activé");

                return BadRequest(ModelState);
            }

            if (!Hash.Equal(utilisateur.Password, current.Password))
             {
                 ModelState.AddModelError("Password", "Mot de passe incorrect");
                 return BadRequest(ModelState);
             }
           

            //current = compteRepository.UpdateAsync(current);

            HttpContext.Session.SetString("compte", JsonConvert.SerializeObject(current));

            return Ok(current);
        }

        [HttpPut]
        public Boolean Deconnexion([FromBody] Utilisateur utilisateur)
        {
            Utilisateur user = this.getSession();

            if (utilisateur != null)
            {

                utilisateur = utilisateurRepository[utilisateur.Idutilisateur];
                this.utilisateurRepository.UpdateAsync(utilisateur);
                HttpContext.Session.Remove("compte");
                return true;
            }
            return false;
        }

        [HttpGet]
        public Utilisateur getSession()
        {
            Utilisateur utilisateur = null;
            string stringcompte = HttpContext.Session.GetString("compte");


            if (stringcompte != null)
            {
                utilisateur = JsonConvert.DeserializeObject<Utilisateur>(stringcompte);
            }

            return utilisateur;
        }

    }
}
