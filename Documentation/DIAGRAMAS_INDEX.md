# NERVA - Diagramas UML Organizados

## 📊 Índice de Diagramas

### 🏗️ **Visão Geral do Sistema**
- [`NERVA_System_Architecture_Overview.puml`](NERVA_System_Architecture_Overview.puml) - Arquitetura geral e módulos

### 🔧 **Entidades Principais**
- [`NERVA_Core_Entities.puml`](NERVA_Core_Entities.puml) - Entidades base e funcionários

### 📋 **Módulos por Domínio**

#### 🔐 Controle de Acesso
- [`NERVA_Access_Control_Module.puml`](NERVA_Access_Control_Module.puml) - Papéis, permissões e auditoria

#### ✅ Pipeline de Aprovações
- [`NERVA_Approval_Workflow_Module.puml`](NERVA_Approval_Workflow_Module.puml) - Fluxos e aprovações

#### 📦 Logística
- [`NERVA_Logistics_Module.puml`](NERVA_Logistics_Module.puml) - Produtos, estoque e compras

#### 🏢 Movimentação em Postos de Trabalho
- [`NERVA_Workplace_Movement_Module.puml`](NERVA_Workplace_Movement_Module.puml) - Postos, atribuições e movimentações

#### 👥 Gestão de Visitantes
- [`NERVA_Visitor_Management_Module.puml`](NERVA_Visitor_Management_Module.puml) - Módulo completo de gestão de visitantes

#### 🤝 Gestão de Empresas Parceiras
- [`NERVA_Partner_Company_Management.puml`](NERVA_Partner_Company_Management.puml) - Gestão de empresas parceiras e funcionários terceiros

#### 📅 Reserva de Recursos
- [`NERVA_Resource_Reservation_Management.puml`](NERVA_Resource_Reservation_Management.puml) - Sistema de reserva de recursos

#### 📊 Análise de KPIs
- [`NERVA_KPI_Analytics_Management.puml`](NERVA_KPI_Analytics_Management.puml) - KPIs e indicadores operacionais

#### 🚨 Gestão de Incidentes
- [`NERVA_Incident_Management.puml`](NERVA_Incident_Management.puml) - Gestão de incidentes e ocorrências

#### 🚗 Vehicle Tracking & IoT
- [`NERVA_Vehicle_Tracking_IoT.puml`](NERVA_Vehicle_Tracking_IoT.puml) - Rastreamento de veículos e dispositivos IoT

#### 👥 Client Management
- [`NERVA_Client_Management.puml`](NERVA_Client_Management.puml) - Gestão de clientes e contratos

#### 🏢 Multi-Tenant Architecture
- [`NERVA_Multi_Tenant_Architecture.puml`](NERVA_Multi_Tenant_Architecture.puml) - Arquitetura multi-tenant

### 🔗 **Visão Integrada**
- [`NERVA_Complete_Modular.puml`](NERVA_Complete_Modular.puml) - Sistema completo com relacionamentos

### 📝 **Diagramas Detalhados (por Entidade)**
- [`./NERVA/src/Domain/Entities/Employee.puml`](./NERVA/src/Domain/Entities/Employee.puml) - Detalhes das entidades de funcionários
- [`./NERVA/src/Domain/Entities/AccessControl.puml`](./NERVA/src/Domain/Entities/AccessControl.puml) - Detalhes do controle de acesso
- [`./NERVA/src/Domain/Entities/ApprovalWorkflow.puml`](./NERVA/src/Domain/Entities/ApprovalWorkflow.puml) - Detalhes dos workflows
- [`./NERVA/src/Domain/Entities/Logistics.puml`](./NERVA/src/Domain/Entities/Logistics.puml) - Detalhes da logística
- [`./NERVA/src/Domain/Entities/WorkplaceMovement.puml`](./NERVA/src/Domain/Entities/WorkplaceMovement.puml) - Detalhes dos postos de trabalho
- [`./NERVA/src/Domain/Entities/VisitorManagement.puml`](./NERVA/src/Domain/Entities/VisitorManagement.puml) - Detalhes da gestão de visitantes
- [`./NERVA/src/Domain/Entities/PartnerCompany.puml`](./NERVA/src/Domain/Entities/PartnerCompany.puml) - Detalhes da gestão de empresas parceiras
- [`./NERVA/src/Domain/Entities/ResourceReservation.puml`](./NERVA/src/Domain/Entities/ResourceReservation.puml) - Detalhes da reserva de recursos
- [`./NERVA/src/Domain/Entities/KPIMetric.puml`](./NERVA/src/Domain/Entities/KPIMetric.puml) - Detalhes dos KPIs e métricas
- [`./NERVA/src/Domain/Entities/Incident.puml`](./NERVA/src/Domain/Entities/Incident.puml) - Detalhes da gestão de incidentes

## 📊 Diagrama Completo para Exportação SVG

### 🎯 **NERVA_Complete_System_SVG.puml** - **⭐ PRINCIPAL PARA SVG**
- **Descrição**: Diagrama UML completo com todos os domínios organizados em packages/solutions
- **Propósito**: Exportação como SVG único contendo todo o sistema
- **Características**:
  - Todas as entidades em um único arquivo
  - Organizado em packages visuais (caixinhas)
  - Relacionamentos inter-domínios
  - Otimizado para exportação SVG
  - Cores diferenciadas por domínio
- **Recomendado para**: Visualização completa do sistema, apresentações, documentação oficial
- **Instruções**: Veja `EXPORT_SVG_INSTRUCTIONS.md` para detalhes de exportação

## 🎯 **Como Visualizar**

### Para VS Code:
1. Instale a extensão **PlantUML** 
2. Abra qualquer arquivo `.puml`
3. Pressione `Alt+D` para preview
4. Use `Ctrl+Shift+P` → "PlantUML: Export Current Diagram" para exportar

### Para Visualização Online:
1. Copie o conteúdo de qualquer arquivo `.puml`
2. Cole em [PlantUML Online](http://www.plantuml.com/plantuml/uml/)
3. Visualize o diagrama renderizado

### Para Geração Local:
```bash
# Com Java e plantuml.jar
java -jar plantuml.jar *.puml

# Gerar todos os diagramas em PNG
java -jar plantuml.jar -tpng *.puml

# Gerar todos os diagramas em SVG
java -jar plantuml.jar -tsvg *.puml
```

## 📐 **Proporções Otimizadas**

Cada diagrama foi otimizado para:
- **Visualização em tela**: Proporção 16:9
- **Impressão**: Formato A4/Letter
- **Apresentação**: Foco em módulos específicos
- **Documentação**: Relacionamentos claros

## 🔍 **Navegação Recomendada**

1. **Começar com**: `NERVA_System_Architecture_Overview.puml`
2. **Entender o core**: `NERVA_Core_Entities.puml`
3. **Explorar módulos**: Cada arquivo de módulo específico
4. **Visão completa**: `NERVA_Complete_Modular.puml`
5. **Detalhes**: Arquivos na pasta `./NERVA/src/Domain/Entities/`

## ⚙️ **Benefícios da Organização Modular**

- ✅ **Diagramas menores** - Melhor visualização
- ✅ **Foco específico** - Um domínio por diagrama  
- ✅ **Reutilização** - Includes para composição
- ✅ **Manutenção** - Fácil atualização por módulo
- ✅ **Apresentação** - Ideal para documentação
- ✅ **Performance** - Renderização mais rápida
