Scrobbler for KbMedia Player
============================

## 概要

Scrobbler for KbMedia Player は、 KbMedia Player で再生しているメディアの情報を、Last.fm に通知するためのアプリケーションです。

KbMedia Player ( http://hwm5.gyao.ne.jp/kobarin/ ) は、Kobarin 様が開発する Windows 用音楽プレイヤーです。
Last.fm ( https://www.last.fm/ ) は、CBSインタラクティブが運営するSNSサービスです。Last.fm では再生情報の通知を「Scrobble」と言います。

本アプリケーションは、KbMedia Player で再生する音楽の再生情報を Last.fm に Scrobble することで、音楽の再生履歴を残すことを目的としています。


## 動作環境

* .NET Framework 4.5 が動作する Windows 環境 ( Windows 10 Pro 64bitで動作確認 )
* KbMedia Player ( 3.03 以降を推奨 )
* 登録済みの Last.fm ユーザアカウント


## データ構成

* ScrobblerForKbMediaPlayer.exe        (プログラム本体)
* ScrobblerForKbMediaPlayer.exe.config (プログラム設定ファイル)
* ScrobblerForKbMediaPlayer.exe.xml    (ユーザ設定ファイル、自動生成)
* NDde.dll                             ( .NET Library for Dynamic Data Exchange )
* Hqub.Lastfm.dll                      ( Last.fm API FULL )
* Mono.HttpUtility.dll                 ( Mono.HttpUtility )


## 使い方

1. プログラムの起動
    1. ScrobblerForKbMediaPlayer.exe を実行します。

2. ユーザ認証
    1. タスクトレイアイコンを右クリックし、「設定」を選択します。
    2. 「認証」ボタンを押します。
    3. Webブラウザにアプリケーション接続許可を求める画面が表示されるので、アプリケーションの接続を許可します。
    4. 表示されているアプリケーションダイアログの「OK」ボタンを押します。
    5. ユーザ情報にユーザ名とアイコンが表示されると、ユーザ認証は完了となります。

3. タスクトレイメニュー
    * Top Page: Last.fmのトップページを開きます。
    * User Pgae: ユーザアカウントのページを開きます。未認証の場合は無効です。
    * Title: 再生中メディアのトラックページを開きます。
    * Artist: 再生中メディアのアーティストページを開きます。
    * Album: 再生中メディアのアルバムページを開きます。
    * Scrobble: 再生中メディアに対し、手動でScrobbleを実行します。
    * Love: 再生中メディアをLoved Tracksに追加します。
    * Unlove: 再生中メディアをLoved Tracksから削除します。
    * 設定: 設定ウィンドウを開きます。
    * 終了: アプリケーションを終了します。

4. 動作仕様
    * KbMedia Player でメディアを再生を開始すると、Last.fm に NowPlaying を通知します。
    * KbMedia Player で一定時間メディアを再生し続けると、Last.fm に Scrobble します。
    * Scrobble に失敗した場合、設定ファイルに保存され次回 Scrobble 時に同時に送信されます。
    * Scrobble にはタイトル、アーティストの両方が必要です。
    * タスクトレイアイコンを右クリック


## 設定

* NowPlaying の通知の ON/OFF を切り替えることができます。
* Scrobble の ON/OFF を切り替えることができます。
* Scrobble のタイミングを変更することができます。


## ライセンス

[MIT]


## 作者

[wa2c]
* https://bitbucket.org/wa2c/
* https://github.com/wa2c


## 履歴

2017-03-20: Ver.1.0 リリース

