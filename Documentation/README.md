# NERVA - Sistema de Gestão Empresarial

Este projeto implementa um sistema completo de gestão empresarial com os seguintes módulos:

## 📋 Módulos Implementados

### 1. **Controle de Funcionários**
- **Employee**: Entidade principal para funcionários
- **Department**: Departamentos da empresa
- **Position**: Cargos disponíveis
- **EmployeeStatus**: Status do funcionário (Ativo, Inativo, Licença, etc.)
- **EmployeeStatusChange**: Histórico de mudanças de status

### 2. **Controle de Acesso**
- **AccessRole**: Papéis/funções no sistema
- **Permission**: Permissões específicas
- **RolePermission**: Relacionamento entre papéis e permissões
- **EmployeeRole**: Papéis atribuídos aos funcionários
- **AccessLog**: Log de acessos ao sistema

### 3. **Pipeline de Aprovações**
- **ApprovalWorkflow**: Fluxos de aprovação configuráveis
- **ApprovalStep**: Etapas do fluxo de aprovação
- **ApprovalRequest**: Solicitações de aprovação
- **ApprovalAction**: Ações tomadas pelos aprovadores
- **ApprovalStatus**: Status das solicitações
- **ApprovalDecision**: Decisões dos aprovadores

### 4. **Sistema de Logística**
- **Warehouse**: Armazéns/depósitos
- **Supplier**: Fornecedores
- **ProductCategory**: Categorias de produtos
- **Inventory**: Controle de estoque
- **PurchaseOrder**: Ordens de compra
- **PurchaseOrderItem**: Itens das ordens de compra
- **StockMovement**: Movimentações de estoque
- **ShipmentOrder**: Ordens de envio
- **ShipmentItem**: Itens das ordens de envio

### 5. **Sistema de Movimentação em Postos de Trabalho**
- **WorkPlace**: Postos de trabalho com capacidade e localização
- **WorkPlaceType**: Tipos (Escritório, Mesa, Sala, Laboratório, etc.)
- **WorkPlaceAssignment**: Atribuições de funcionários a postos
- **WorkPlaceMovementRequest**: Solicitações de movimentação
- **WorkPlaceMovementHistory**: Histórico de movimentações
- **WorkPlaceSchedule**: Horários de trabalho por posto
- **WorkPlaceReservation**: Reservas temporárias
- **WorkPlaceEquipment**: Equipamentos por posto
- **WorkPlaceAccess**: Controle de acesso físico
- **WorkPlaceMetrics**: Métricas de ocupação e utilização

## 🔄 Fluxos de Processo

### Mudança de Status de Funcionário
1. **Solicitação**: Um funcionário/gestor solicita mudança de status
2. **Aprovação**: A solicitação passa pelo pipeline de aprovação configurado
3. **Execução**: Após aprovação, o status é alterado
4. **Auditoria**: Todas as mudanças são registradas

### Controle de Acesso
1. **Autenticação**: Funcionário faz login
2. **Autorização**: Sistema verifica permissões baseado nos papéis
3. **Auditoria**: Todos os acessos são registrados

### Processo de Compras
1. **Requisição**: Funcionário solicita compra
2. **Aprovação**: Passa pelo pipeline de aprovação
3. **Ordem de Compra**: Criada após aprovação
4. **Recebimento**: Produtos são recebidos e estoque atualizado

### Processo de Envio
1. **Solicitação**: Departamento solicita produtos
2. **Aprovação**: Passa pelo pipeline de aprovação
3. **Separação**: Produtos são separados no estoque
4. **Envio**: Produtos são enviados com tracking

### Movimentação em Postos de Trabalho
1. **Solicitação**: Funcionário/gestor solicita mudança de posto
2. **Validação**: Sistema verifica capacidade e disponibilidade
3. **Aprovação**: Passa pelo pipeline de aprovação configurado
4. **Agendamento**: Movimentação é agendada para data específica
5. **Execução**: Funcionário é movido para novo posto
6. **Histórico**: Movimentação é registrada no histórico
7. **Métricas**: Dados de ocupação são atualizados

## 🏗️ Arquitetura

### Camadas da Aplicação
- **Domain**: Entidades de negócio e regras
- **Application**: Casos de uso e comandos/queries
- **Infrastructure**: Acesso a dados e serviços externos
- **Web**: API e interface do usuário

### Padrões Implementados
- **CQRS**: Separação de comandos e consultas
- **MediatR**: Mediator pattern para desacoplamento
- **Domain Events**: Eventos de domínio para efeitos colaterais
- **Repository Pattern**: Abstração de acesso a dados
- **Clean Architecture**: Separação de responsabilidades

## 🛠️ Tecnologias
- **.NET 8**: Framework principal
- **Entity Framework Core**: ORM
- **MediatR**: Mediator pattern
- **FluentValidation**: Validação de comandos
- **ASP.NET Core**: Web API
- **SQL Server**: Banco de dados

## 📊 Diagramas UML

Os diagramas estão organizados em:
- `Employee.puml`: Entidades de funcionários
- `AccessControl.puml`: Entidades de controle de acesso
- `ApprovalWorkflow.puml`: Entidades de workflow de aprovação
- `Logistics.puml`: Entidades de logística
- `WorkplaceMovement.puml`: Entidades de movimentação em postos de trabalho
- `CompleteDomainModel.puml`: Modelo completo com relacionamentos

## 🚀 Próximos Passos

1. **Implementar Entidades**: Criar as classes C# baseadas nos diagramas
2. **Configurar EF Core**: Mapeamento das entidades
3. **Implementar Commands/Queries**: Casos de uso da aplicação
4. **Criar APIs**: Endpoints para cada módulo
5. **Implementar Testes**: Testes unitários e de integração
6. **Interface do Usuário**: Dashboard e formulários

## 📝 Observações

- Todas as entidades herdam de `BaseAuditableEntity` para auditoria
- O sistema de aprovação é flexível e configurável
- O controle de acesso é baseado em papéis e permissões
- O sistema de logística integra com o controle de funcionários
- Eventos de domínio são utilizados para notificações e integrações
