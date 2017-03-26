Scrobbler for KbMedia Player
============================

## 概要

Scrobbler for KbMedia Player は、 KbMedia Player で再生しているメディアの情報を、Last.fm に通知するためのアプリケーションです。

KbMedia Player ( http://hwm5.gyao.ne.jp/kobarin/ ) は、Kobarin 様が開発する Windows 用音楽プレイヤーです。
Last.fm ( https://www.last.fm/ ) は、CBSインタラクティブが運営するSNSサービスです。

Last.fm では、再生情報を自分のアカウントに通知することを「Scrobble」と言います。本アプリケーションは、KbMedia Player で再生する音楽の再生情報を Last.fm に Scrobble することで、音楽の再生履歴を残すことを目的としています。


## 動作環境

* .NET Framework 4.5 が動作する Windows 環境 ( Windows 10 Pro 64bitで動作確認 )
* KbMedia Player ( 3.03 以降を推奨 )
* 登録済みの Last.fm ユーザアカウント


## 開発環境

* Windows 10 Pro 64bit
* Visual Studio Community 2015
* .NET Framework 4.5


## 構成ファイル

* ScrobblerForKbMediaPlayer.exe        (プログラム本体)
* ScrobblerForKbMediaPlayer.exe.config (プログラム設定ファイル)
* ScrobblerForKbMediaPlayer.exe.xml    (ユーザ設定ファイル、自動生成)
* NDde.dll                             ( .NET Library for Dynamic Data Exchange )
* Hqub.Lastfm.dll                      ( Last.fm API FULL )
* Mono.HttpUtility.dll                 ( Mono.HttpUtility )


## インストール方法

1. 構成ファイルをフォルダに展開します。
2. ScrobblerForKbMediaPlayer.exe.xml は、初回起動時に自動的に生成されます。


## 使い方

1. プログラムの起動

    1. ScrobblerForKbMediaPlayer.exe を実行します。
    2. アプリケーションのアイコンがタスクトレイに追加され、プログラムが常駐します。

2. ユーザ認証

    1. タスクトレイアイコンを右クリックし、「設定」を選択します。
    2. 「認証」ボタンを押します。
    3. Webブラウザにアプリケーション接続許可を求める画面が表示されるので、アプリケーションの接続を許可します。
    4. 表示されているアプリケーションダイアログの「OK」ボタンを押します。
    5. ユーザ情報にユーザ名とアイコンが表示されると、ユーザ認証は完了となります。

3. タスクトレイメニュー
    
    タスクトレイアイコンを右クリックすると、メニューを表示します。
    
    * Top Page: Last.fmのトップページを開きます。
    * User Pgae: ユーザアカウントのページを開きます。未認証の場合は無効です。
    * Title: 再生中メディアのタイトルを表示します。選択するとトラックページを開きます。
    * Artist: 再生中メディアのアーティスト名を表示します。選択するとアーティストページを開きます。
    * Album: 再生中メディアのアルバム名を表示します。選択するとアルバムページを開きます。
    * Scrobble: 再生中メディアに対し、手動でScrobbleを実行します。
    * Love: 再生中メディアをLoved Tracksに追加します。
    * Unlove: 再生中メディアをLoved Tracksから削除します。
    * 設定: 設定ウィンドウを開きます。
    * 終了: アプリケーションを終了します。

4. 動作仕様
    * KbMedia Player でメディアを再生を開始すると、Last.fm に NowPlaying を通知します。
    * KbMedia Player で一定時間メディアを再生し続けると、Last.fm に Scrobble します。
    * Scrobble に失敗した場合、再生情報が設定ファイルに保存され、次回 Scrobble 時に自動的に同時に送信されます。
    * Scrobble 等の操作には、タイトル、アーティストの両方が必要です。


## 設定

* NowPlaying の通知の ON/OFF を切り替えることができます。
* Scrobble の ON/OFF を切り替えることができます。
* Scrobble のタイミングを変更することができます。


## ダウンロード

実行ファイルは、GitHubより入手してください。

* https://github.com/wa2c/scrobbler-for-kbmedia-player/releases


## ライセンス

[MIT]
* https://github.com/wa2c/scrobbler-for-kbmedia-player/blob/master/LICENCE.md


## 作者

[wa2c]
* https://bitbucket.org/wa2c/
* https://github.com/wa2c


## 履歴

2017-03-20: Ver.1.0 リリース

2017-03-26: Ver.1.1 リリース
* 起動後にScrobbleされない問題を修正しました。
* 接続がエラーとなった際の処理を修正しました。
