# 📝 Cálculo Salarial com Polimorfismo (C\#)

Este projeto é um sistema de console em C\# que demonstra o uso de **Polimorfismo** para calcular salários de diferentes categorias de funcionários.

## ⚙️ Como Funciona

O sistema utiliza **Herança** e **Abstração** para tratar todas as categorias de forma uniforme, enquanto o **Polimorfismo** garante que a regra salarial correta seja aplicada a cada funcionário.

| Categoria | Cálculo Salarial | Conceito de POO |
| :--- | :--- | :--- |
| **`Funcionario`** | Classe Base Abstrata. | **Abstração** e **Herança** |
| **`Administrativo`** | Salário Base + 10% | **Polimorfismo** |
| **`Técnico`** | Salário Base + 20% | **Polimorfismo** |
| **`Estagiário`** | Metade do Salário Base | **Polimorfismo** |

## 🚀 Execução

1.  O usuário cadastra múltiplos funcionários (Administrativo, Técnico, Estagiário) em uma **única lista**.
2.  O programa itera sobre a lista e chama o método **`CalcularSalario()`**.
3.  O C\# executa a regra específica de cada categoria, mostrando o salário final correto no relatório.
4.  Possui validação robusta para evitar erros ao digitar opções de menu.

---

**Tecnologias:** C\# | Programação Orientada a Objetos (POO) | Console App
