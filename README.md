# TeamTooManyPeople

실행파일 다운로드
->
18.05.10

https://drive.google.com/open?id=1rS1tbrWaKPnjOd1TghYCfD5TCXMn8J3d


패치 노트 #23

1. 이제 플레이어가 자동으로 뒤로 밀려나지 않음.
-> Shooting_Move에서 코드 추가

2. 처음부터 모든 오브젝트들이 활성화되있으면 좀 그러니까 분기점마다
   SetActive() 를 시켜주는 것들을 추가

3. 추가 탄환은 그냥 안함. 컨셉이랑도 안맞는거같고
   만들기도 너무 어려움.. 

4. 여기저기 체력아이템이랑 시간 아이템 추가

5. 시간 다되면 구름이 사라지고 터지는 모션 추가
-> 이것도 Shooting_Move에 코드 추가