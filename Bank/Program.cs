using System.ComponentModel;
using System.Runtime.CompilerServices;
//using static Bank.Account;


// Modificadores de acesso
//public = Qualquer um pode acessar
//private = Apenas a classe pode acessar
//protetecd = Apenas a classe e as filhas das classes podem acessar
//internal = Visivel em todo lugar, mas apenas dentro do mesmo projeto 

// Modificadores de comportamento 
//virtual = Permite à classe filha herdar o comportamento do método, mas alterar caso seja necessário com o override 
//abstract = A classe filha é obrigada a implementar a classe-mãe utilizando override para sobrescrever
//sealed = Impede que qualquer um mude o comportamento ou herde ela 
//static = O método pertence a classe e não ao objeto

// Exepctions de argumento
// ArgumentException - Erro de argumento inválido (Ex.: Espera-se decimal e recebe string)
// ArgumentNullException - Erro de argumento vazio 
// ArgumentOutOfRangeException - Erro de arugmento fora do intervalo (Ex.: Número negativo em idade)

// Exceções de estado 
// InvalidOperationException - Quando o argumento é válido, mas o método não permite a operação (É como trocar o pneu de um carro com ele em movimento)
// NotImplementedException - Lembrete ao dev de que aquele código ainda não está pronto 
// NullReferenceException - Tentar acessar algo que está nulo 

// Exceções matemáticas
// DivideByZero - Não precisa nem dizer
// IndexOutRangeException - Acessar o índice de um array inexistente
// StackOverflowException - Ocorre quando acontece recursões infinitas (Por infinitas caixas dentro de uma gaveta pequena)

// cada classe tem um arquivo diferente

