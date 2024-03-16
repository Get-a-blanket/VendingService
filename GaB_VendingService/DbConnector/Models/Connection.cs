using System.ComponentModel.DataAnnotations;

namespace GaB_VendingService.DbConnector.Models
{
    /// <summary>
    /// Способ подключения к автомату
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Guid
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Guid автомата, к которому относится подключение 
        /// </summary>
        [Required]
        public VendingMachine VendingMachine { get; set; }

        /// <summary>
        /// Guid автомата, к которому относится подключение 
        /// </summary>
        [Required]
        public Guid VendingMachineId { get; set; }

        /// <summary>
        /// Строка подключения к автомату
        /// </summary>
        [Required]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Разрешение на использование подключения
        /// </summary>
        [Required]
        public bool Enabled { get; set; }
    }
}
