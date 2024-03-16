using System.ComponentModel.DataAnnotations;

namespace GaB_VendingService.DbConnector.Models
{
    /// <summary>
    /// Статус ячейки
    /// </summary>
    public class CellStatus
    {
        /// <summary>
        ///  Id
        /// </summary>
        [Key]
        public Int16 Id { get; set; }

        /// <summary>
        /// Индификатор состояния
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
