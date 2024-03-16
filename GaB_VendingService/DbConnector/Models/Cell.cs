using System.ComponentModel.DataAnnotations;

namespace GaB_VendingService.DbConnector.Models
{
    /// <summary>
    /// Ячейка автомата
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Guid
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Автомат, к которому относится ячейка
        /// </summary>
        [Required]
        public VendingMachine VendingMachine { get; set; }

        /// <summary>
        /// Id автомата, к которому относится ячейка
        /// </summary>
        [Required]
        public Guid VendingMachineId { get; set; }

        /// <summary>
        /// Статус использования ячейки
        /// </summary>
        [Required]
        public CellStatus CellStatus { get; set; }

        /// <summary>
        /// Id статуса использования ячейки 
        /// </summary>
        [Required]
        public Int16 CellStatusId { get; set; }

        /// <summary>
        /// Разрешение на использование ячейки
        /// </summary>
        [Required]
        public bool Enabled { get; set; }
    }
}
