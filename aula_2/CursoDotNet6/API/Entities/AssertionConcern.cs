namespace API.Entities
{
    public class AssertionConcern
    {
        /// <summary>
        /// Validação de tamanho máximo de string
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="maximum"></param>
        /// <param name="message"></param>
        /// <exception cref="DomainException"></exception>
        public static void AssertArgumentLength(string stringValue, int maximum, string message)
        {
            int length = stringValue.Trim().Length;
            if (length > maximum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Validação de tamanho minimo e máximo (precisa estar entre os dois)
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="message"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Validação de string se esta vazia
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="message"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Validação se objeto é null
        /// </summary>
        /// <param name="object1"></param>
        /// <param name="message"></param>
        /// <exception cref="DomainException"></exception>
        public static void AssertArgumentNotNull(object object1, string message)
        {
            if (object1 == null)
            {
                throw new DomainException(message);
            }
        }
    }
}
