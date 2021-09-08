pipeline{
    agent any

    environment{

        DOCKER_REGISTRY_CREDENTIALS=credentials('docker-registry-guillenmartins')
        GIT_FTP_CREDENTIALS=credentials('ftp-credentials')
    }
    tools{

        maven 'Maven'
    }
    parameters{
    
        booleanParam(name:"executeTests", defaultValue:true,description:"Execute tests in stage or not")
        choice(name:"VERSION",choices:['1.0','1.1'],description:"Version of app to run")
        string(name:"FTP.LOCATION",defaultValue:"/Users/renatomartins/Documents/Development/AWS/S3/jenkins publish/",description:"Ftp location")
    }
    stages{
        stage("build"){

        
            steps{
                echo "========executing A========"
            }  
        }

        stage("tests"){

        when {

            expression{
                params.executeTests==true
            }
        }

         steps{

                echo "Tests being done"
            }

        }
        stage("publish"){
            steps{
                echo "========executing A========"
                withCredentials([string(credentials:'ftp-credentials',usernameVariable:'FTP_USERNAME',passwordVariable:'FTP_PASSWORD')]){

                    sh 'git ftp init --user ${GIT_FTP_CREDENTIALS_USR} --passwd ${GIT_FTP_CREDENTIALS_PSW} ftp://${FTP.LOCATION}'
                }
            }
            
        }
    }
    post{
        
        success{
            echo "========pipeline executed successfully ========"
        }
        failure{
            echo "========pipeline execution failed========"
        }

        always{
            echo "========always========"
            echo "Jenkinsfile end"
        }
    }
}