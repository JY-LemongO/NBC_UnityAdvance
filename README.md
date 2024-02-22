# NBC_UnityAdvance
국지윤 - Unity 심화 주차 개인과제 (미완성)

## 프로젝트 이름 : Module Lab
### 프로젝트 설명 : Title 씬에서 Player의 파츠를 원하는 구성으로 조립 후 해당 Module로 Main 씬 진입하여 Play

![13](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/488ab3fc-2436-469e-9f39-e62c3ebed8c9)

---
### 현재 구현된 내용
- 3D 카메라 및 UI
- 동적 생성
- 하체 파츠 변경 및 상체 높이 재설정
- 상체 파츠 변경
- Module 3D UI 에서 파츠 별 능력치 Text출력
- Title 씬에서 변경된 파츠를 Main 씬에 가져가기
   

### 구현 해야할 내용
- 조립된 Module 이동
- 파츠 높이에 따른 카메라 오프셋
- 상체 파츠별 다른 공격
- 데이터 저장   

### 제출 기한내 목표 구현
- 상체 파츠 변경 - 완
- Module 3D UI 에서 파츠 별 능력치 Text출력 - 완

---

#### 세부내용

- 생략될 내용 : 이전 개인 프로젝트에서 구현
  - 동적 생성
  - UI Text 출력

<details>
  <summary>3D 카메라 및 UI</summary>
  
  - 마우스 커서 움직임에 맞춰 제한된 영역만큼 카메라 Rotation 변화.
![GIFGIF](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/f691e5aa-bfdc-4d69-80dd-2325ed4f0e79)
  - 옵션 선택 시 카메라 회전 및 해당 Rotation에서 따라가기 지속
![GIFGIF](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/427ced5c-bc4a-40da-ac25-b18cdcda558c)
- 카메라 로직
  - 지급 강의의 내용을 토대로 CameraStateBase가 CameraStatMachine을 역참조 하는 형식으로 사용.
  - State에 상관없이 FixedUpdate로 커서에 따라 화면 따라가기 연출을 해야 하기에 State 전환 시 화면 전환동안 FixedUpdate 무시 조건이 필요.
  - 해결 방법으로 코루틴 사용을 선택. Monobehaivor 필요로 인해 역참조된 CameraStateMachine의 코루틴 호출 메서드를 활용.
  
</details>

<details>
  <summary>파츠 변경</summary>
  
![2](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/22cd84d0-2620-4321-801a-5fcb2288470a)
![3](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/bce331c2-9272-4690-8d81-3b6fcdfb1002)


- 구현 방법
  - 상, 하체로 구별된 모듈, ModuleManager의 ChangeParts 메서드를 이용해 각 부위별 현재 Parts 저장.
  - 실제 보여질 모듈에서 ModuleManager의 Action 구독으로 파츠 교체 시, 해당 파츠를 삭제 및 생성.
  - 하체 파츠의 경우 상체 파츠까지 파괴(높이가 다르기 때문에 Joint의 하위에있음) 및 상체 파츠가 생성될 부모 Transform 재할당.
  - 하체 파츠 변경시 상체 파츠는 같은 파츠를 재생성, 재할당된 위치에서 생성되어 높이 조정되어있음.
  - 상체 파츠만 변경시 하체 파츠 변경과 같은로직.
 
  ![14](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/721a097c-9582-44e3-815a-40470ce4648c)

  
</details>

<details>
  <summary>ModuleSO</summary>
  
- 파츠별 Armor, Weight가 다르기 때문에 합산하여 최종 능력치를 계산.
- 파츠마다 다른 능력치 및 사용 로직으로 인하여 개별 클래스 및 개별 능력치SO 할당 (로직 미구현) - 모든 파츠 클래스는 Parts를 상속

  ![10](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/dc587ab4-58eb-49b7-a93a-3495f729e032)
  ![11](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/3a57df5a-7e07-4385-9c72-6a7a317d24d8)
  ![12](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/badfe010-0e2c-4d94-9382-741316386e9e)

  
</details>

<details>
  <summary>조립한 모듈 Main 씬에 적용</summary>
  
- ModuleManager에 저장된 현재 파츠 정보를 씬이 넘어갈 때 생성된 Module에서 해당 파츠로 생성

![15](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/e6d8e775-2ec4-473a-ab00-5ec52f9db83e)
![16](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/89d59e3e-7ae4-48eb-af93-b83bbc8d05cc)

- 실제 움직임을 가진 Module은 조작이 가능한 컴포넌트 부착하여 이동(예정)

![1](https://github.com/JY-LemongO/NBC_UnityAdvance/assets/122505119/6758fffd-173e-418b-815f-20466be63b9b)
  
</details>

