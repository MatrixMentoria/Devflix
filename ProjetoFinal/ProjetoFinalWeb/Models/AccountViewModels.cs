using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinalWeb.Models
{
    /// <summary>
    /// ViewModel para confirmação de email.
    /// </summary>
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// ViewModel para integração com Google, Facebook, etc...
    /// </summary>
    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    /// <summary>
    /// ViewModel para envio de código de confirmação.
    /// </summary>
    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// ViewModel para verificação do código de confirmação.
    /// </summary>
    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage="Campo Obrigatório")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Código de verificação")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Deseja que o navegador se lembre da senha?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// ViewModel para esquecimento de senha de login.
    /// </summary>
    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// ViewModel para login.
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage= "Insira um email válido. Exemplo: zezinho@hotmail.com")]
        [RegularExpression("^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$",ErrorMessage="Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Deseja que o navegador se lembre?")]
        public bool RememberMe { get; set; }
    }

    /// <summary>
    /// ViewModel para registro, cadastro de usuários. 
    /// </summary>
    public class RegisterViewModel
    {
        //O Philipe tinha visto, e colocado o mesmo regex. Porém quando vi está parte estava faltando.
        [RegularExpression("(?=^.{2,60}$)^[A-ZÁ-ÚÀ-ÙÄ-Ü][a-zá-úà-ùä-ü]+(?:[ ](?:das?|dos?|de|e|[A-ZÁ-ÚÀ-ÙÄ-Ü][a-zá-úà-ùä-ü]+))*$", ErrorMessage = "Nome Inválido!  Ex: João dos Santos")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        [EmailAddress(ErrorMessage ="Insira um email válido. Exemplo: zezinho@hotmail.com")]
        [Display(Name = "Email")]
        [RegularExpression("^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$", ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A {0} deve conter no mínimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação da mesma não conferem.")]
        public string ConfirmPassword { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }

    /// <summary>
    /// ViewModel para reset/troca de senha.
    /// </summary>
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage="Insira um email válido.Exemplo: zezinho@hotmail.com")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A {0} deve conter no mínimo {2} caracteres .", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação da mesma não conferem.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    /// <summary>
    /// ViewModel de esquecimento de senha.
    /// </summary>
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage= "Insira um email válido. Exemplo: zezinho@hotmail.com")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
