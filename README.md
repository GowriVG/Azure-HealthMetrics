# Azure Health Monitor

![Version](https://img.shields.io/badge/version-1.0.0-blue)
![Backend](https://img.shields.io/badge/backend-.NET%208%20Web%20API-512BD4)
![Frontend](https://img.shields.io/badge/frontend-Angular%2019-DD0031)
![Azure](https://img.shields.io/badge/cloud-Azure-0078D4)
![License](https://img.shields.io/badge/license-Internal-lightgrey)

Azure Health Monitor is an internal observability dashboard for tracking the health and performance of Azure Function Apps and App Service Plans. It surfaces stopped apps, resource utilization metrics, and OS distribution data through a clean Angular dashboard backed by an ASP.NET Core Web API — giving operations teams an at-a-glance view of their Azure environment.

---

## Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Features](#features)
- [Project Structure](#project-structure)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Backend Setup](#backend-setup)
  - [Frontend Setup](#frontend-setup)
- [API Reference](#api-reference)
- [Configuration](#configuration)
- [Running Tests](#running-tests)
- [Building for Production](#building-for-production)
- [Security](#security)

---

## Overview

Azure Health Monitor queries App Service Plan and Function App telemetry and presents it in a unified dashboard. Engineers can immediately identify stopped Function Apps, spot resource plans under high CPU or memory pressure, and understand the OS distribution of their infrastructure — all without leaving the browser.

---

## Architecture

```mermaid
graph TD
    A[ASP.NET Core Web API\nlocalhost:7064] -->|JSON Response| B[Angular Frontend\nlocalhost:4200]
    B --> C[Dashboard Component]
    C --> D[Agent Health Snapshot\nDonut Chart]
    C --> E[OS Distribution\nDonut Chart]
    C --> F[Top CPU Utilization\nBar Chart]
    C --> G[Stopped Function Apps\nTable]
    C --> H[Running Function Apps\nTable]
    C --> I[App Service Plans\nTable]
    A --> J[DashboardController\nGET /api/dashboard]
    J --> K[DashboardResponseDto]
    K --> L[FunctionAppDto\nRunning Apps]
    K --> M[FunctionAppDto\nStopped Apps]
    K --> N[AppServicePlanDto]
