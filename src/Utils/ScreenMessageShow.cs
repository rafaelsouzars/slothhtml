using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slothhtml.src.Utils
{
    public class ScreenMessageShow
    {
        /// <summary>
        /// Mostra uma mensagem personalizada no console da aplicação.
        /// </summary>
        /// <param name="messageScheme">
        /// Schema da mensagem:
        /// 
        /// <code>
        /// new { title: "title", message: "my message", color: ConsoleColor.White }
        /// </code>
        /// O parâmetro color é opcional
        /// </param>
        public ScreenMessageShow(dynamic messageScheme)
        {
            // Armazena a cor de fonte padrão do console
            var defaultForegroundColor = Console.ForegroundColor;

            try 
            {
                if (messageScheme != null) 
                { 
                    // Recupera valores do objeto
                    var title = messageScheme?.title ?? string.Empty; 
                    var message = messageScheme?.message ?? string.Empty;
                    var color = messageScheme?.color ?? defaultForegroundColor;

                    // Monta o screen da mensagem
                    Console.ForegroundColor = color ?? defaultForegroundColor;
                    Console.WriteLine($"{title, -10}:");
                    Console.WriteLine($"\t{message}\n");
                    Console.WriteLine(new string('-', 20),"\n");
                }
                else 
                {
                    throw new Exception("O parâmetro de configuração não pode ser nulo.");
                }
            }
            catch (Exception error) when (messageScheme?.color != typeof(ConsoleColor)) 
            {
                // Mensagem de error
                Console.ForegroundColor = ConsoleColor.Red; // Muda a cor do console para Red
                Console.WriteLine($"Error de argumento: {error.Message}"); // Dispara mensagem de error
                Console.ForegroundColor = defaultForegroundColor;
            }
            catch (Exception error) 
            {
                // Mensagem de error
                Console.ForegroundColor = ConsoleColor.Red; // Muda a cor do console para Red
                Console.WriteLine($"Error: {error.Message}"); // Dispara mensagem de error
                Console.ForegroundColor = defaultForegroundColor;

            }
        }
    }
}

/**
 * Area de snippet
 */

// messageScheme.GetType().GetProperty("title")?.GetValue(messageScheme, null);
