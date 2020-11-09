# 실내 위치인식 기반 증강현실 게임

## 사용 기술
- Android Studio - RSSI(Wifi 신호 강도)값을 Unity3D에서 사용할 수 있도록 라이브러리 생성
- Unity3D - 게임 개발
- Kudan AR SDK - 증강현실 기능 개발
- MySQL - 실내 각 위치에 대한 각 AP의 RSSI 값 저장

## 관련 알고리즘
1. fingerprinting
  - 위치마다 모든 AP의 RSSI값을 저장하여 현재 값과 비교햐여 위치 측정하는 방식
  - 해당 위치의 디바이스에서 측정된 RSSI값과 DB 값의 유사도를 통해 위치를 측정하므로, 장애물 사항을 반영하기 쉽다.
  - 정확도는 삼변 측량보다 좋으나, DB값과 현재 측정된 RSSI의 유사도를 판단하는 알고리즘을 직접 구현해야 한다. 
2. 삼변 측량
  - 각 AP의 위치를 좌표화해서 알고있다는 가정 하에 측정하는 방식
  - RSSI값을 통해 구한 거리와 좌표 평면상의 거리 공식을 이요해 현재 좌표를 구하는 방식
  - 공식을 사용하여 구현이 편하나, AP와 디바이스 사이의 신호 간섭, 신호 미약을 반영하기 힘듬.
