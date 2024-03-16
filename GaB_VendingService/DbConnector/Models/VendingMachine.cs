using System.ComponentModel.DataAnnotations;

namespace GaB_VendingService.DbConnector.Models
{
    /// <summary>
    /// Вендинговый аппапарат, он же автомат
    /// </summary>
    public class VendingMachine
    {
        /// <summary>
        /// Guid
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        
        /// <summary>
        /// Разрешение на использование автмата
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Доступные подключения к автомату
        /// </summary>
        public List<Connection> Connections { get; set; }

        /// <summary>
        /// Ячейки автомата
        /// </summary>
        public List<Cell> Cells { get; set; }
    }
}
