# 🌐 Domain Hunter

![License](https://img.shields.io/github/license/kenanexe/DomainHunter)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)
![Platform](https://img.shields.io/badge/platform-Windows-0078D6)

A minimalist and practical tool for quickly checking domain status via the RDAP protocol.

## 🚀 What Does It Do?

Import your bulk domain list into the app and instantly find out domain availability status using up-to-date RDAP data.

## ✨ Key Features

- **Bulk Querying:** Add and check as many domains as you want in a single batch.
- **Direct RDAP Integration:** Get fast and reliable data without the limitations of traditional WHOIS.
- **Clean Interface:** A simple, no-clutter design that stays focused on the task.
- **Export Results:** Save your query results in CSV format (Excel export coming soon).
- **Resume Anytime (SQLite-backed):** Pending domains and results are saved to a local SQLite database as you go. Closed the app mid-query? Reopen it and resume exactly where you left off with a single click.
- **Auto TLD:** Type just the name (e.g. `kenan`) and select from the suggested TLDs — it automatically completes it to `kenan.bio`, etc.
- **Auto Speed:** Automatically paces queries (~1 domain/sec) to stay fast while avoiding RDAP rate limits.
- **Duplicate Protection:** Before adding a domain, it checks both the current queue and existing results — so the same domain never gets queued or queried twice.

## 🖼️ Screenshot
<img width="1037" height="572" alt="resim" src="https://github.com/user-attachments/assets/24a31fd7-8516-4149-8a5d-0cee3d97e6fe" />

## 🛠️ Installation & Usage

1. Clone the repository or download it as a `.zip`:
   ```bash
   git clone https://github.com/KenanExe/DomainHunter.git
   ```
2. Open `DomainHunter.sln` with Visual Studio (2022 or later).
3. Build the project and run it (F5 or Ctrl+F5).
4. Once the app is open:
   - Enter the domains you want to check in the text box (one domain per line).
   - Click the **Check** button.
   - Results will be displayed in the list.
5. Use the **Save as CSV** button to export your results.
6. Closed the app mid-query? No problem — your remaining queue and results are stored in a local SQLite database, so you can pick up right where you left off with one click.

## 📋 Requirements

- .NET 8.0 SDK or later
- Windows operating system (this is a WinForms application)
- Internet connection (required for RDAP queries)
- Note: some corporate/restricted networks may block RDAP endpoints — make sure outbound HTTPS is allowed

## 🗺️ Roadmap

- [x] CSV export
- [ ] Excel (.xlsx) export
- [ ] Bulk domain import from file (.txt/.csv)

## 🤝 Contributing

This is an open-source project — contributions are welcome!

1. Fork the repository
2. Create a new branch (`git checkout -b feature/your-feature`)
3. Commit your changes
4. Open a pull request

Bug reports and feature suggestions are also welcome via [Issues](https://github.com/KenanExe/DomainHunter/issues).

## 📄 License

This project is licensed under the MIT License — see the [LICENSE](LICENSE.txt) file for details.

[![License](https://img.shields.io/github/license/kenanexe/DomainHunter)](LICENSE.txt)
