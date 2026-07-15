# C# & ASP.NET Core MVC 学習ハンズオン教材

C# の基本構文から、Minimal API を使った Web の基礎、そして本格的な ASP.NET Core MVC のフォーム処理までを段階的に学習できるハンズオン教材プロジェクトです。
VS Code および **GitHub Codespaces** での学習に対応しており、環境構築不要でブラウザだけで開始できます。

---

## 🚀 学習ロードマップ

本教材は以下の 4 ステップで構成されています。

### 📂 1. `01_ConsoleApp` (Step 1: コンソールの基本)
- **学ぶこと**: 変数、関数の定義、基本的なデバッグ・プログラムの実行方法。
- **ハンズオン**: 引き算メソッド（`Hikizan`）の作成と呼び出し。

### 📂 2. `02_MinimalWebApi` (Step 2: Web API の基本)
- **学ぶこと**: Web サーバーの仕組み、ルーティング、クエリパラメータの受け取り。
- **ハンズオン**: `/hikizan` エンドポイントを実装し、引き算の結果を Web に返す処理。

### 📂 3. `03_MvcCalculator` (Step 3: MVC の基礎)
- **学ぶこと**: MVC（Model-View-Controller）パターン、Controller から View へのデータ受け渡し（`ViewBag`）、Razor構文。
- **ハンズオン**: 引き算結果を ViewBag に設定し、ブラウザ画面に動的表示する処理。

### 📂 4. `03_MvcCalculator` (Step 4: 実践フォーム編)
- **学ぶこと**: HTML フォーム（`<form>`）を介した POST 送信、Controller でのデータバインディング、結果画面（Result）へのビュー遷移。

---

## 📖 進め方

### 💻 パターン A: ローカル環境で実行する場合

#### 前提条件
1. **[.NET SDK 10.0 以降](https://dotnet.microsoft.com/download)** をインストール
2. **[Visual Studio Code](https://code.visualstudio.com/)** をインストール
3. VS Code 拡張機能 **C# Dev Kit** と **CodeTour** をインストール

#### 手順
1. **リポジトリをクローンして VS Code で開く**:
2. **CodeTour を開始する**:
   - アクティビティバー（アイコンが並ぶ場所）にある「**Explorer**」のアイコンをクリックします。
   - サイドバーの下部にある「CodeTour」から`01: Console App Basics` を選択し、ツアーを開始します。

---

### ☁️ パターン B: GitHub Codespaces を使う場合（環境構築不要）

1. **Codespace を起動する**:
   - 本リポジトリの GitHub ページ上部にある緑色の「**<> Code**」ボタンをクリックします。
   - 「**Codespaces**」タブを選択し、「**Create codespace on main**」をクリックします。
   - ブラウザ上で VS Code 環境が立ち上がります（.NET SDK や必要な拡張機能は自動でセットアップされます）。

2. **CodeTour を開始する**:
   - 起動後、画面左側の   - アクティビティバー（アイコンが並ぶ場所）にある「**Explorer**」のアイコンをクリックします。
   - サイドバーの下部にある「CodeTour」から`01: Console App Basics` を選択し、ツアーを開始します。

