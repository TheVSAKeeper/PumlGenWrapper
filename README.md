# PumlGen Wrapper

## Description

PumlGen Wrapper is a Windows Forms application that acts as a graphical user interface (GUI) for the `puml-gen`
command-line tool. This application allows users to generate PlantUML diagrams from source code directories with various
customization options.

## Features

- **Input and Output Path Selection**: Easily select input and output directories using file dialogs.
- **Exclude Paths**: Specify paths to exclude from processing.
- **Command Options**: Various command-line options for customizing the diagram generation.
- **Separate Mode**: Run the command separately for each subdirectory in the input path.
- **All-In-One Mode**: Combine diagrams from all subdirectories into a single file.
- **Settings Persistence**: Save and load settings automatically.
- **Output Directory Management**: Check and manage the output directory before running the command.

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/TheVSAKeeper/PumlGenWrapper.git
   ```

2. Open the solution in Visual Studio.
3. Build and run the application.

## Prerequisites

To use PumlGen Wrapper, you need to have the `puml-gen` tool installed. You can download and install it from
the [PlantUmlClassDiagramGenerator](https://github.com/pierre3/PlantUmlClassDiagramGenerator) repository. Follow the
instructions provided in the repository to set up the tool.

## Usage

1. **Select Input Path**: Click the "Browse..." button next to the Input Path text box to select the input directory.
2. **Select Output Path**: Click the "Browse..." button next to the Output Path text box to select the output directory.
3. **Specify Exclude Paths**: Enter the paths to exclude in the Exclude Paths text box.
4. **Set Command Options**: Check the desired command options.
5. **Run Command**: Click the "Execute" button to run the `puml-gen` command with the specified settings.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Описание

PumlGen Wrapper — это приложение Windows Forms, которое выступает в роли графического интерфейса пользователя (GUI) для
инструмента командной строки `puml-gen`. Это приложение позволяет пользователям генерировать диаграммы PlantUML из
каталогов исходного кода с различными параметрами настройки.

## Возможности

- **Выбор путей ввода и вывода**: Легко выбирайте входные и выходные каталоги с помощью диалоговых окон.
- **Исключение путей**: Укажите пути, которые нужно исключить из обработки.
- **Параметры команды**: Различные параметры командной строки для настройки генерации диаграмм.
- **Режим отдельного выполнения**: Запускайте команду отдельно для каждого подкаталога в пути ввода.
- **Режим All-In-One**: Объединяйте диаграммы из всех подкаталогов в один файл.
- **Сохранение настроек**: Автоматическое сохранение и загрузка настроек.
- **Управление выходным каталогом**: Проверка и управление выходным каталогом перед запуском команды.

## Установка

1. Клонируйте репозиторий:
   ```sh
   git clone https://github.com/TheVSAKeeper/PumlGenWrapper.git
   ```
2. Откройте решение в Visual Studio.
3. Скомпилируйте и запустите приложение.

## Предварительные условия

Для использования PumlGen Wrapper вам необходимо установить инструмент `puml-gen`. Вы можете скачать и установить его из
репозитория [PlantUmlClassDiagramGenerator](https://github.com/pierre3/PlantUmlClassDiagramGenerator). Следуйте
инструкциям, предоставленным в репозитории, чтобы настроить инструмент.

## Использование

1. **Выберите путь ввода**: Нажмите кнопку "Browse..." рядом с текстовым полем Input Path, чтобы выбрать входной
   каталог.
2. **Выберите путь вывода**: Нажмите кнопку "Browse..." рядом с текстовым полем Output Path, чтобы выбрать выходной
   каталог.
3. **Укажите исключаемые пути**: Введите пути для исключения в текстовое поле Exclude Paths.
4. **Установите параметры команды**: Установите флажки для нужных параметров команды.
5. **Запустите команду**: Нажмите кнопку "Execute", чтобы запустить команду `puml-gen` с указанными настройками.

## Вклад в проект

Вклад в проект приветствуется! Пожалуйста, откройте issue или отправьте pull request.

## Лицензия

Этот проект лицензирован под лицензией MIT. Смотрите файл [LICENSE](LICENSE) для подробностей.
