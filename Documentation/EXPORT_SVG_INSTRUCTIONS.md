# NERVA - Sistema Completo para Exportação SVG

## 📋 Visão Geral

Este arquivo (`NERVA_Complete_System_SVG.puml`) contém o diagrama UML completo do sistema NERVA (Real-Time Operations Tracking) organizado em packages/solutions para facilitar a visualização e exportação como SVG.

## 🏗️ Estrutura do Diagrama

### 1. **Core Framework** 
- `BaseEntity` - Base para todas as entidades
- `BaseAuditableEntity` - Base para entidades auditáveis
- `BaseEvent` - Base para eventos do domínio
- `ValueObject` - Base para objetos de valor

### 2. **Employee Management** (Gestão de Funcionários)
- `Employee` - Entidade principal de funcionários
- `Department` - Departamentos da empresa
- `Position` - Cargos/posições
- `EmployeeStatus` - Status dos funcionários
- `EmployeeStatusHistory` - Histórico de mudanças de status
- `EmployeeDocument` - Documentos dos funcionários

### 3. **Access Control** (Controle de Acesso)
- `AccessRole` - Papéis de acesso
- `Permission` - Permissões do sistema
- `RolePermission` - Relacionamento entre papéis e permissões
- `EmployeeRole` - Papéis atribuídos aos funcionários
- `AccessLog` - Log de acessos
- `SecurityPolicy` - Políticas de segurança

### 4. **Approval Workflow** (Fluxo de Aprovações)
- `ApprovalWorkflow` - Fluxos de aprovação
- `ApprovalStep` - Etapas dos fluxos
- `ApprovalRequest` - Solicitações de aprovação
- `ApprovalAction` - Ações de aprovação
- `ApprovalTemplate` - Templates de aprovação
- `ApprovalNotification` - Notificações do sistema

### 5. **Logistics** (Sistema de Logística)
- `Warehouse` - Armazéns/depósitos
- `WarehouseLocation` - Localizações dentro dos armazéns
- `Product` - Produtos
- `ProductCategory` - Categorias de produtos
- `Inventory` - Estoque
- `StockMovement` - Movimentações de estoque
- `Supplier` - Fornecedores
- `PurchaseOrder` - Pedidos de compra
- `PurchaseOrderItem` - Itens dos pedidos

### 6. **Workplace Movement** (Movimentação de Postos de Trabalho)
- `WorkPlace` - Postos de trabalho
- `WorkPlaceAssignment` - Atribuições de postos
- `WorkPlaceMovementRequest` - Solicitações de mudança
- `WorkPlaceEquipment` - Equipamentos dos postos
- `WorkShift` - Turnos de trabalho
- `WorkPlaceSchedule` - Agendamentos de postos

### 7. **Visitor Management** (Gestão de Visitantes)
- `Visitor` - Entidade principal de visitantes
- `VisitorPreRegistration` - Pré-cadastro com QR/token
- `VisitorAccess` - Check-in/check-out com rastreamento
- `AccessArea` - Áreas de acesso
- `VisitorAccessRule` - Regras específicas (horário, área, responsável)
- `VisitorNotification` - Notificações automáticas
- `VisitorBadge` - Controle de crachás

### 8. **Partner Company Management** (Gestão de Empresas Parceiras)
- `PartnerCompany` - Empresas parceiras
- `PartnerEmployee` - Funcionários terceiros
- `PartnerContract` - Contratos e regras
- `PartnerCompliance` - Compliance e treinamentos
- `PartnerReport` - Relatórios por empresa

### 9. **Resource Reservation** (Reserva Inteligente de Recursos)
- `Resource` - Recursos disponíveis (salas, veículos, equipamentos)
- `ResourceReservation` - Reservas inteligentes
- `ResourceRule` - Regras de negócio
- `ResourceUsage` - Controle de uso real
- `IoTSensor` - Sensores para verificação

### 10. **Compliance & Policy Engine** (Compliance e Políticas)
- `ComplianceRule` - Regras configuráveis
- `PolicyViolation` - Log de violações
- `ExceptionRequest` - Aprovações especiais
- `ComplianceReport` - Relatórios de compliance

### 11. **KPI & Analytics** (KPIs e Indicadores)
- `KPIMetric` - Métricas operacionais
- `AnalyticsReport` - Relatórios analíticos
- `Dashboard` - Dashboards em tempo real
- `PerformanceIndicator` - Indicadores de performance

### 12. **Incident Management** (Gestão de Incidentes)
- `Incident` - Registro de ocorrências
- `IncidentType` - Classificação de incidentes
- `IncidentResolution` - Workflow de tratamento
- `IncidentEscalation` - Escalação automática

### 13. **Vehicle Tracking & IoT** (Gestão de Localização de Veículos)
- `Vehicle` - Veículos da frota
- `VehicleTracking` - Dados de GPS
- `VehicleRoute` - Rotas e trajetos
- `VehicleAlert` - Alertas automáticos
- `IoTDevice` - Dispositivos IoT

### 14. **Client Management** (Gestão de Clientes)
- `Client` - Cadastro de clientes
- `ClientContact` - Contatos do cliente
- `ClientAccessRole` - Controle de acesso
- `ClientReport` - Relatórios por cliente

### 15. **Multi-Tenant Architecture** (Arquitetura Multi-Operações)
- `Tenant` - Multi-empresa/filial
- `TenantConfiguration` - Configurações por operação
- `TenantUser` - Usuários segregados
- `TenantData` - Isolamento de dados

## 🔗 Relacionamentos Inter-Packages

O diagrama inclui relacionamentos entre todos os packages:
- **Employee Management ↔ Access Control**: Funcionários têm papéis e geram logs
- **Employee Management ↔ Approval Workflow**: Funcionários fazem solicitações e aprovações
- **Employee Management ↔ Logistics**: Funcionários gerenciam armazéns e fazem pedidos
- **Employee Management ↔ Workplace Movement**: Funcionários são atribuídos a postos
- **Access Control ↔ Approval Workflow**: Papéis controlam aprovações
- **Visitor Management ↔ Employee Management**: Visitantes têm responsáveis e aprovadores
- **Visitor Management ↔ Access Control**: Controle de acesso baseado em permissões
- **Visitor Management ↔ Approval Workflow**: Fluxo de aprovação para visitas
- **Visitor Management ↔ Workplace Movement**: Acesso a áreas vinculadas a postos de trabalho

## 📊 Como Exportar como SVG

### Opção 1: PlantUML Online
1. Acesse: https://www.plantuml.com/plantuml/uml/
2. Cole o conteúdo do arquivo `NERVA_Complete_System_SVG.puml`
3. Clique em "Submit"
4. Clique em "SVG" para baixar o arquivo SVG

### Opção 2: VS Code com PlantUML Extension
1. Instale a extensão "PlantUML" no VS Code
2. Abra o arquivo `NERVA_Complete_System_SVG.puml`
3. Pressione `Ctrl+Shift+P` (ou `Cmd+Shift+P` no Mac)
4. Digite "PlantUML: Export Current Diagram"
5. Escolha "svg" como formato

### Opção 3: Linha de Comando (Java)
```bash
# Navegue até o diretório do arquivo
cd f:\NERVA\uml

# Execute o PlantUML para gerar SVG
java -jar plantuml.jar -tsvg NERVA_Complete_System_SVG.puml
```

### Opção 4: Docker
```bash
# Navegue até o diretório do arquivo
cd f:\NERVA\uml

# Execute com Docker
docker run --rm -v ${PWD}:/work -w /work plantuml/plantuml:latest -tsvg NERVA_Complete_System_SVG.puml
```

## 🎨 Características Visuais

- **Cores diferenciadas** para cada package
- **Relacionamentos claros** entre entidades
- **Organização modular** em caixinhas/packages
- **Legenda visual** com títulos descritivos
- **Otimizado para SVG** com alta qualidade

## 📏 Observações sobre o Tamanho

⚠️ **Importante**: Este diagrama é **muito grande** devido à complexidade e quantidade de entidades. Recomenda-se:

1. **Visualizar em tela cheia** ou monitor grande
2. **Usar zoom** para focar em áreas específicas
3. **Imprimir em formato A0 ou A1** se necessário
4. **Usar a versão digital** para navegação interativa

## 🔍 Navegação Recomendada

1. **Visão Geral**: Comece pelos packages principais
2. **Detalhamento**: Foque em um package por vez
3. **Relacionamentos**: Siga as setas para entender as conexões
4. **Referência**: Use os diagramas modulares para detalhes específicos

## 📁 Arquivos Relacionados

- `NERVA_Complete_System_SVG.puml` - Diagrama completo (este arquivo)
- `NERVA_Summary.puml` - Visão resumida
- `NERVA_System_Architecture_Overview.puml` - Arquitetura geral
- Diagramas modulares individuais por domínio

---

**Nota**: Este diagrama representa a estrutura completa do sistema NERVA. Para visualizações mais específicas, consulte os diagramas modulares individuais no diretório `uml/`.
