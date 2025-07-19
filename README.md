# KAutoHunt
## Descrição
---
KAutoHunt é uma interface de automação que utiliza modelos treinados (.h5) para reconhecimento de objetos em jogos e execução de ações automatizadas. O projeto integra C# com Python, utilizando modelos criados no Teachable Machine.
---
## Funcionamento
---
O script utiliza um modelo treinado e um arquivo .txt contendo os nomes dos monstros detectáveis. Os modelos devem ser criados pelo Teachable Machine, utilizando imagens extraídas via GRF Editor. Há um script auxiliar na pasta Utils do projeto que formata as imagens automaticamente.

Cada modelo deve ser treinado separadamente por mapa. Não misture monstros de diferentes mapas no mesmo modelo, pois isso causará falhas no reconhecimento.

Após o treinamento, o modelo gerado deve ser salvo na pasta zimap com o nome correspondente ao warp do mapa, por exemplo: mosk_dun01 ou pay_fild08.

Caso o mapa não apareça no combo box do script, extraia os arquivos .h5 e .txt correspondentes para a pasta Maps, garantindo que ambos tenham o mesmo nome.
---
## Como utilizar

    No campo "Pasta do script" da interface, selecione a pasta raiz do script baixado.

    Os caminhos dos mapas e modelos serão reconhecidos automaticamente.

    Configure os mapas e os monstros desejados para caça.

    Inicie o script pela interface. A execução é assíncrona e, após a mensagem de confirmação, o script estará pronto para uso.

    Use Home para abrir a aba de debug.

    Use End para iniciar o script. A confirmação de execução é o ajuste inicial automático da tela.

## Observações

    O script utiliza detecção de imagens. Melhor desempenho gráfico resultará em melhor reconhecimento.

    Atualmente, não é detectável pelo jogo, mas não se trata de um bot completo. É necessário uso manual de poções, buffs e habilidades.

    Há um problema conhecido no qual o uso de habilidades pode parar. Um clique manual no mouse ou na habilidade normaliza a execução.

## Status

Em desenvolvimento. Algumas funcionalidades ainda estão em ajuste, assim como a organização e documentação completa do código.
