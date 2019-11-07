using Blacksmith.Localized.Attributes;
using Blacksmith.Validations.Localizations;

namespace SharedShopping.Domain.Localizations
{
    [Culture("es-ES")]
    public class EsDomainStrings : EsValidatorStrings, IDomainStrings
    {
        public string Contribution_amount_is_positive => "La cantidad de la contribución debe ser positiva.";
        public string Expense_concept_cannot_be_empty => "El concepto del gasto no puede estar vacío.";

        public string Tag_name_cannot_be_empty => "La etiqueta requiere de un nombre.";
        public string Data_object_has_no_id => "Falta el identificador en el objeto de datos.";
        public string User_name_cannot_be_empty => "El usuario requiere de un nombre.";
        public string Expense_date_must_be_after_year_1900 => "La fecha del gasto debe ser posterior al 1900 d.c.";
    }
}
