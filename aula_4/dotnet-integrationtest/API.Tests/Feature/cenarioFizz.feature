Funcionalidade: Resposta financeiras

Cenário: Verificar se a resposta contém cotações financeiras
Dado que eu tenha uma resposta JSON com dados de cotações financeiras
Quando eu desserializar a resposta para um objeto TrendingResponse
Então a propriedade count do objeto Result deve ser maior que 0