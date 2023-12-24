import mediapipe as mp
import cv2
import socket
import struct


width,height = 1920,1080


movement = "idle"

ok_flag = True;

mp_drawing = mp.solutions.drawing_utils
mp_hands = mp.solutions.hands
            
cap = cv2.VideoCapture(0)
cap.set(3,width)
cap.set(4,height)


#Communication
sock=socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
serverAddressPort=("127.0.0.1",5053)
command = 1
'''
def receive_integer():
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind(("127.0.0.1", 12345))  # Use the same IP and port as in Unity
    server_socket.listen(1)

    print("Waiting for Unity connection...")
    client_socket, client_address = server_socket.accept()
    print("Unity connected!")

    data = client_socket.recv(4)  # Assuming a 32-bit integer
    received_integer = struct.unpack('I', data)[0]
    
    

    print("Received Integer from Unity:", received_integer)

    client_socket.close()
    server_socket.close()
     
    return received_integer 
   
'''


with mp_hands.Hands(min_detection_confidence=0.8, min_tracking_confidence=0.5) as hands: 
    while ok_flag:

        
        ok_flag, frame = cap.read()
        
        # BGR 2 RGB
        image = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
        
        # Flip on horizontal
        image = cv2.flip(image, 1)
        
        # Set flag
        image.flags.writeable = False
        
        # Detections
        results = hands.process(image)
        
        # Set flag to true
        image.flags.writeable = True
        
        # RGB 2 BGR
        image = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
        
        # Detections
        #print(results)
        
        
        cv2.putText(image, "VIDUMAGA HAND GESTURE TRACKER", (120, 20), cv2.FONT_HERSHEY_SIMPLEX, 0.6, (0, 0 ,255 ), 2)

        
        # Rendering results
        movement = "idle"
        if results.multi_hand_landmarks:
            for num, hand in enumerate(results.multi_hand_landmarks):
                mp_drawing.draw_landmarks(image, hand, mp_hands.HAND_CONNECTIONS, 
                                        mp_drawing.DrawingSpec(color=(121, 22, 76), thickness=2, circle_radius=4),
                                        mp_drawing.DrawingSpec(color=(250, 44, 250), thickness=2, circle_radius=2),
                                        )
                # Get landmarks of thumb and index finger
                
                landmarks_list = []
                data=[]
                for landmark in hand.landmark:
                    landmarks_list.append((width*landmark.x, height-(height*landmark.y), landmark.z))
                    rounded_landmark_X=round(width*landmark.x)
                    rounded_landmark_Y=round(height-(height*landmark.y))
                    rounded_landmark_Z=round(1000*landmark.z)
                    data.extend((rounded_landmark_X, rounded_landmark_Y, rounded_landmark_Z))

                print("Landmarks:", landmarks_list)
                print("Data:",data)
                
                '''index_pip = hand.landmark[mp_hands.HandLandmark.INDEX_FINGER_PIP]
                index_tip = hand.landmark[mp_hands.HandLandmark.INDEX_FINGER_TIP]
                index_mcp = hand.landmark[mp_hands.HandLandmark.INDEX_FINGER_MCP]
                thumb_tip = hand.landmark[mp_hands.HandLandmark.THUMB_TIP]
                thumb_mcp = hand.landmark[mp_hands.HandLandmark.THUMB_MCP]
                wrist = hand.landmark[mp_hands.HandLandmark.WRIST]
                middle_pip = hand.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_PIP]
                middle_tip = hand.landmark[mp_hands.HandLandmark.MIDDLE_FINGER_TIP]
                ring_pip = hand.landmark[mp_hands.HandLandmark.RING_FINGER_PIP]
                ring_tip = hand.landmark[mp_hands.HandLandmark.RING_FINGER_TIP]
                pinky_pip = hand.landmark[mp_hands.HandLandmark.PINKY_PIP]
                pinky_tip = hand.landmark[mp_hands.HandLandmark.PINKY_TIP]
                '''
            
        
            sock.sendto(str.encode(str(data)),serverAddressPort)
            #command=receive_integer()
            

        cv2.imshow('VIDUMAGA - Hand Gesture Tracker', image)
        
        
        if ((cv2.waitKey(1) & 0xFF == ord('q'))|(cv2.waitKey(1) & command == 0)):
            
                #cap.release()
                cv2.destroyWindow("VIDUMAGA - Hand Gesture Tracker") 
                break
            
        

                   


        
          




