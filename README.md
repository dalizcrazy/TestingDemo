# Testing Demo - Proyecto de Pruebas Automatizadas

Este repositorio contiene un conjunto de pruebas automatizadas para aplicaciones web utilizando Selenium WebDriver y NUnit.

## 📋 Descripción del Proyecto

El proyecto está dividido en dos componentes principales:

### 1. UITests - Pruebas de Interfaz de Usuario
- **Tecnologías**: Selenium WebDriver, NUnit
- **Propósito**: Ejecutar pruebas end-to-end en aplicaciones web
- **Características**:
  - Framework de pruebas estructurado
  - Patrón Page Object Model
  - Configuración flexible de drivers

### 2. APITests - Pruebas de API REST
- **Tecnologías**: NUnit, RestSharp, Newtonsoft.Json
- **Propósito**: Ejecutar pruebas automatizadas para servicios web REST
- **Características**:
  - Framework para testing de APIs
  - Manejo de requests y responses HTTP
  - Validación de códigos de estado y esquemas JSON

### Las pruebas se realizan en:
- **APITest:** https://reqres.in/api
- **UITest:** https://the-internet.herokuapp.com/login

## 📦 Prerrequisitos

- .NET Framework [8.0]
- NUnit 3.14
- Selenium WebDriver
- NUnit3TestAdapter

## ⚙️ Configuración

1. **Clonar el repositorio**
   ```bash
   git clone [https://github.com/dalizcrazy/TestingDemo.git]
   cd TestingDemo
   ```

2. **Restaurar paquetes NuGet**
   ```bash
   dotnet restore
   ```

## 🧪 Ejecutar Pruebas

### Ejecutar todas las pruebas
```bash
dotnet test
```

### Ejecutar pruebas específicas
```bash
dotnet test --filter "Login_ValidUser_ShouldLoginSuccessfully"
```
### Ejecutar con Visual Studio Code
- Abre el Solution en Visual Studio Code
- Usa el Test Explorer para ejecutar pruebas individuales o en grupo

### Video Demo Ejecución

![Demo GIF](https://github.com/dalizcrazy/TestingDemo/blob/main/Demo.gif)
