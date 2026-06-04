# EtudiantOS

<!-- adam-badges:start -->
[![commits](https://img.shields.io/github/commit-activity/t/Adam-Blf/EtudiantOS?color=001329&label=commits&style=flat-square)](https://github.com/Adam-Blf/EtudiantOS/commits) [![visites](https://hits.sh/github.com/Adam-Blf/EtudiantOS.svg?style=flat-square&label=visites&color=001329)](https://hits.sh/github.com/Adam-Blf/EtudiantOS/) [![last commit](https://img.shields.io/github/last-commit/Adam-Blf/EtudiantOS?color=D4A437&style=flat-square&label=dernier%20push)](https://github.com/Adam-Blf/EtudiantOS/commits) [![top language](https://img.shields.io/github/languages/top/Adam-Blf/EtudiantOS?style=flat-square)](https://github.com/Adam-Blf/EtudiantOS) [![license](https://img.shields.io/github/license/Adam-Blf/EtudiantOS?style=flat-square&color=D4A437)](LICENSE)
<!-- adam-badges:end -->


![Status](https://img.shields.io/badge/status-academic-blue)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-XAML-5C2D91)
![MVVM](https://img.shields.io/badge/pattern-MVVM-blueviolet)

Application de bureau Windows pour la gestion de la vie etudiante. Interface WPF MVVM avec suivi des cours, notes, absences et emploi du temps.

## Architecture

```mermaid
flowchart TB
    A["MainWindow.xaml<br/>vue WPF · XAML"]
    B["Converters/<br/>converters de liaison XAML"]
    C["ViewModels/<br/>logique de presentation MVVM · binding"]
    D["Services/<br/>acces donnees · logique applicative"]
    E["Models/<br/>entites metier · cours · notes · evenements"]
    F["Persistance locale<br/>stockage des donnees etudiantes"]
    A --> C
    B --> A
    C --> D
    D --> E
    D --> F
```

## Stack

- C# .NET (WPF, XAML)
- Pattern MVVM (Models / ViewModels / Services / Converters)
- Architecture par couches, persistance locale

## Structure

- `Models/` · entites metier (cours, notes, evenements)
- `ViewModels/` · logique de presentation MVVM
- `Services/` · acces donnees et logique applicative
- `Converters/` · converters XAML
- `MainWindow.xaml` · fenetre principale de l'app

## Lancement

```bash
git clone https://github.com/Adam-Blf/EtudiantOS
cd EtudiantOS
dotnet restore
dotnet run
```

Ou ouvrir `EtudiantOS.csproj` dans Visual Studio puis F5.

## Prerequis

- .NET SDK compatible WPF (Windows uniquement)
- Visual Studio 2022 ou VS Code + extension C#

## Licence

MIT

---

<p align="center">
  <sub>Par <a href="https://adam.beloucif.com">Adam Beloucif</a> · Data Engineer & Fullstack Developer · <a href="https://github.com/Adam-Blf">GitHub</a> · <a href="https://www.linkedin.com/in/adambeloucif/">LinkedIn</a></sub>
</p>


## Star History

<a href="https://www.star-history.com/?repos=Adam-Blf%2FEtudiantOS&type=date&legend=top-left">
 <picture>
   <source media="(prefers-color-scheme: dark)" srcset="https://api.star-history.com/chart?repos=Adam-Blf/EtudiantOS&type=date&theme=dark&legend=top-left" />
   <source media="(prefers-color-scheme: light)" srcset="https://api.star-history.com/chart?repos=Adam-Blf/EtudiantOS&type=date&legend=top-left" />
   <img alt="Star History Chart" src="https://api.star-history.com/chart?repos=Adam-Blf/EtudiantOS&type=date&legend=top-left" />
 </picture>
</a>
