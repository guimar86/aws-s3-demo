pipeline{
    agent none

    environment{

        DOCKER_REGISTRY_CREDENTIALS=credentials('docker-registry-guillenmartins')
        GIT_FTP_CREDENTIALS=credentials('ftp-credentials')
    }
    
    parameters{
    
        booleanParam(name:"executeTests", defaultValue:true,description:"Execute tests in stage or not")
        choice(name:"VERSION",choices:['1.0','1.1'],description:"Version of app to run")
        string(name:"FTP.LOCATION",defaultValue:"localhost/Users/renatomartins/Documents/Development/AWS/S3/jenkins publish/",description:"Ftp location")
    }
    stages{
        stage("build"){
 agent {
        docker{image 'mcr.microsoft.com/dotnet/sdk:5.0'}
    }
        
            steps{
                echo "========executing Build of Solution========"
                sh 'dotnet Build'
            }  
        }

        stage("tests"){
 agent {
        docker{image 'mcr.microsoft.com/dotnet/sdk:5.0'}
    }
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
             agent {
        docker{image 'mcr.microsoft.com/dotnet/sdk:5.0'}
    }
            steps{
                echo "========Publish solution========"
               
            sh 'dotnetPublish'
                
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
